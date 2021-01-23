    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                string parent =
                    "<parent>" +
                       "<string id=\"68056\"><![CDATA[Anti-Aliasing:]]></string>" +
                       "<string id=\"68085\"><![CDATA[V Sync:]]></string>" +
                       "<string id=\"68100\"><![CDATA[Frame Limit:]]></string>" +
                       "<string id=\"68125\"><![CDATA[Pixel Light Count:]]></string>" +
                       "<string id=\"68162\"><![CDATA[Shadow Cascades:]]></string>" +
                       "<string id=\"68195\"><![CDATA[* Game requires restart for changes to take effect *]]></string>" +
                       "<string id=\"68300\"><![CDATA[Video & Graphics]]></string>" +
                       "<string id=\"68333\"><![CDATA[Anti-Aliasing:   ]]></string>" +
                       "<string id=\"68368\"><![CDATA[Texture Quality: ]]></string>" +
                       "<string id=\"68403\"><![CDATA[Pixel Light Count: ]]></string>" +
                       "<string id=\"68442\"><![CDATA[Shadow Cascades: ]]></string>" +
                       "<string id=\"68477\"><![CDATA[Graphics]]></string>" +
                       "<string id=\"68494\"><![CDATA[AddonLoader: Exception iterating ']]></string>" +
                    "</parent>";
                StringReader reader = new StringReader(parent);
                XDocument doc = XDocument.Load(reader);
                var results = doc.Root.Elements("string").OrderBy(x => x.Attribute("id").Value);
     
            }
        }
    }
    ​
