	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Xml;
	public class XhtmlWriter : XmlWriterProxy
	{
		readonly Stack<Node> stack = new Stack<Node>();
		readonly Func<string, string, int, bool> filter;
		readonly Func<string, string, int, string> nameEditor;
		readonly bool filterChildren;
		struct Node
		{
			public string prefix;
			public string localName;
			public string ns;
			public Behaviour filter;
		}
		[Flags]
		private enum Behaviour
		{
			StandardXml = 0,
			Exclude = 1,
			ExcludeSelfAndChildren = 2,
			FullClosingTag = 4,
		}
		private string[] selfClosingTags = { "area", "base", "br", "col", "command", "embed", "frame","hr","img","input","keygen","link","meta", "source","track","wbr",
				"path","circle","ellipse","line","polygon","rect","use"    // SVG
		};
		public XhtmlWriter(XmlWriter writer, Func<string, string, int, bool> filter, bool filterChildren)
			: this(writer, filter, null, filterChildren)
		{
		}
		public XhtmlWriter(XmlWriter writer, Func<string, string, int, bool> filter, Func<string, string, int, string> nameEditor, bool filterChildren)
			: base(writer)
		{
			this.filter = filter ?? delegate { return true; };
			this.nameEditor = nameEditor ?? delegate (string localName, string ns, int depth) { return localName; };
			this.filterChildren = filterChildren;
		}
		protected override bool IsSuspended
		{
			get
			{
				if (filterChildren)
				{
					if (stack.Count > 0 && stack.Peek().filter.HasFlag(Behaviour.Exclude))
						return true;
					if (stack.Any(b => b.filter.HasFlag(Behaviour.ExcludeSelfAndChildren)))
						return true;
				}
				return base.IsSuspended;
			}
		}
		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			var write = filter(localName, ns, stack.Count);
			var newLocalName = nameEditor(localName, ns, stack.Count);
			if (write)
				base.WriteStartElement(prefix, newLocalName, ns);
			Node x;
			x.filter = write ? Behaviour.StandardXml : Behaviour.Exclude;
			x.localName = localName;
			x.prefix = prefix;
			x.ns = ns;
			if (!selfClosingTags.Any( t=> (t == localName)))
			{
				x.filter |= Behaviour.FullClosingTag;
			}
			stack.Push( x);
		}
		public override void WriteEndElement()
		{
			var node = stack.Pop();
			if (!node.filter.HasFlag(Behaviour.Exclude))
			{
				if (node.filter.HasFlag(Behaviour.FullClosingTag))
				{
					if (node.localName == "script")
					{
						base.WriteString(" ");
					}
					base.WriteFullEndElement();
				}
				else
					base.WriteEndElement();
			}
		}
	}
	
	public class XmlWriterProxy : XmlWriter
	{
		readonly XmlWriter baseWriter;
		public XmlWriterProxy(XmlWriter baseWriter)
		{
			if(baseWriter == null)
				throw new ArgumentNullException();
			this.baseWriter = baseWriter;
		}
		protected virtual bool IsSuspended { get { return false; } }
		public override void Close()
		{
			baseWriter.Close();
		}
		public override void Flush()
		{
			baseWriter.Flush();
		}
		public override string LookupPrefix(string ns)
		{
			return baseWriter.LookupPrefix(ns);
		}
		public override void WriteBase64(byte[] buffer, int index, int count)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteBase64(buffer, index, count);
		}
		public override void WriteCData(string text)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteCData(text);
		}
		public override void WriteCharEntity(char ch)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteCharEntity(ch);
		}
		public override void WriteChars(char[] buffer, int index, int count)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteChars(buffer, index, count);
		}
		public override void WriteComment(string text)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteComment(text);
		}
		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteDocType(name, pubid, sysid, subset);
		}
		public override void WriteEndAttribute()
		{
			if(IsSuspended)
				return;
			baseWriter.WriteEndAttribute();
		}
		public override void WriteEndDocument()
		{
			if(IsSuspended)
				return;
			baseWriter.WriteEndDocument();
		}
		public override void WriteEndElement()
		{
			if(IsSuspended)
				return;
			baseWriter.WriteEndElement();
		}
		public override void WriteEntityRef(string name)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteEntityRef(name);
		}
		public override void WriteFullEndElement()
		{
			if(IsSuspended)
				return;
			baseWriter.WriteFullEndElement();
		}
		public override void WriteProcessingInstruction(string name, string text)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteProcessingInstruction(name, text);
		}
		public override void WriteRaw(string data)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteRaw(data);
		}
		public override void WriteRaw(char[] buffer, int index, int count)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteRaw(buffer, index, count);
		}
		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteStartAttribute(prefix, localName, ns);
		}
		public override void WriteStartDocument(bool standalone)
		{
			baseWriter.WriteStartDocument(standalone);
		}
		public override void WriteStartDocument()
		{
			baseWriter.WriteStartDocument();
		}
		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteStartElement(prefix, localName, ns);
		}
		public override WriteState WriteState
		{
			get { return baseWriter.WriteState; }
		}
		public override void WriteString(string text)
		{
			if(IsSuspended)
				return;
		
			baseWriter.WriteString(text);
		}
		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteSurrogateCharEntity(lowChar, highChar);
		}
		public override void WriteWhitespace(string ws)
		{
			if(IsSuspended)
				return;
			baseWriter.WriteWhitespace(ws);
		}
	}
