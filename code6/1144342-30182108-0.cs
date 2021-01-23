    namespace Custom.Business.SC.Extensions.Pipelines.RenderField
    {
        using System;
    
        using HtmlAgilityPack;
    
        using Sitecore;
        using Sitecore.Diagnostics;
        using Sitecore.Pipelines.RenderField;
    
        /// <summary>Class that renders a rich text field with removed image dimensions.</summary>
        public class GetFieldValue : Sitecore.Pipelines.RenderField.GetFieldValue
        {
            /// <summary>The process method.</summary>
            /// <param name="args">The render field arguments.</param>
            public new void Process(RenderFieldArgs args)
            {
                base.Process(args);
                
                // Do not modify output if the field is not a rich text field,
                // or if the page is in page editor mode
                if (args.FieldTypeKey != "rich text" || string.IsNullOrEmpty(args.FieldValue) || Context.PageMode.IsPageEditorEditing)
                {
                    return;
                }                       
                
                // stripping dimension attributes from images
                Profiler.StartOperation("Stripping dimension attributes from image field: " + args.FieldName);
                args.Result.FirstPart = this.StripImageDimensions(args.Result.FirstPart);
                Profiler.EndOperation();
            }
    
            /// <summary>The strip image dimensions.</summary>
            /// <param name="text">The text.</param>
            /// <returns>The <see cref="string"/>.</returns>
            private string StripImageDimensions(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }
    
                var outText = text;
                try
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(outText);
                    this.StripAttribute(doc, "width");
                    this.StripAttribute(doc, "height");
                    this.StripAttribute(doc, "style");
                    outText = doc.DocumentNode.WriteContentTo();
                }
                catch (Exception)
                {
                }
    
                return outText;
            }
    
            /// <summary>The strip attribute.</summary>
            /// <param name="doc">The doc.</param>
            /// <param name="attribute">The attribute.</param>
            private void StripAttribute(HtmlDocument doc, string attribute)
            {
                // HtmlAgilityPack returns null instead of an empty collection when the query finds no results.  
                var nodes = doc.DocumentNode.SelectNodes(string.Format("//img[@{0}]", attribute));
                if (nodes == null || nodes.Count.Equals(0))
                {
                    return;
                }
    
                foreach (var node in nodes)
                {
                    node.Attributes[attribute].Remove();
                }
            } 
        }  
    }
