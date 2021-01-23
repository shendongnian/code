    using System;
    using System.Data;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    
    namespace WebApplication1
    {
        public partial class _Default : Page
        {
            protected XmlNodeList myNodes = null;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                string booksXml = @"<books>
                    <book category='web'>
                        <title>Columbus Sailed the Ocean Blue</title>
                        <year>1492</year>
                        <price>6 gold doubloons</price>
                        <authors>
                            <author>Vaidyanathan Nagarajan</author>
                            <author>john doe</author>
                            <author>jane doe</author>
                        </authors>
                    </book>
                    <book category='web'>
                        <title>Best Book Ever</title>
                        <year>1776</year>
                        <price>23.55</price>
                        <authors>
                            <author>Robert Frost</author>
                        </authors>
                    </book>
                    <book category='web'>
                        <title>Hello World!</title>
                        <year>20013</year>
                        <price>49.99</price>
    
                    </book>
                    <book category='web'>
                        <title>1234</title>
                        <year>1999</year>
                        <price>69.99</price>
                        <authors>
                            <author>Carmen SanDiego</author>
                            <author>Roger Rabbit</author>
                        </authors>
                    </book>
                </books>";
    
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(booksXml);
    
                //doc.ChildNodes[0] is the entire books element and al of its children
                //doing .ChildNodes again gives you all of the book elements
                this.myNodes = doc.ChildNodes[0].ChildNodes;
            }
        }
    }
