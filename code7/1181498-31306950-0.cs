    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace messyXml {
    class Program {
        const String almostXml = @"
    @#$%random junk
    <Fruits>
      <Apples>
        Pies
      </Apples>
      <Pears>
        Tarts
      </Pears>
    </Fruits>
    This is some junk about Fruits like Apples and Pears 
    which can be made into Pies and Tarts.  I think that
    Pears<Apples.  Edge case might be <Parts or /Apples>
    <Parts No='123'>
      Pie Plate
    </Parts>";
    
        static void Main(string[] args) {
            Console.WriteLine("Extracting XML from:");
            Console.WriteLine(almostXml);
            Console.WriteLine();
            int i = 0;
            var validXml = new StringBuilder();
            while (i < almostXml.Length) {
                if (almostXml[i] == '<') { // might be an xml start
                    int ix = almostXml.IndexOfAny(" >\t".ToArray(), i + 1); 
                    // this only check for space, > and tab, you may want to
                    // include other whitespace chars
                    if (ix < 0) {
                        ix = almostXml.IndexOf("/>", i + 1); // you might have <element/>
                        if (ix >= 0) {
                            // you could check if element name is valid
                            var xml = almostXml.Substring(i, (ix + 2) - i);
                            try {
                                // see if this is really xml
                                var doc = XDocument.Parse(xml);
                                validXml.AppendLine(xml);
                                i = ix + 2;
                                continue; // next iteration of while i 
                                }
                            catch (System.Xml.XmlException) {
                                // do nothing
                                }
                            }
                        ix = almostXml.IndexOf(">", i + 1); // you might have <element/>
                        }
                    else { // we found something like <element ...
                        var ix2 = almostXml.IndexOf('>', ix); // where is the '>'
                        if (ix2 >= 0) {
                            // build an end tag
                            var endtag = "</" + almostXml.Substring(i + 1, (ix - i) - 1) + ">";
                            var endix = almostXml.IndexOf(endtag, ix2);
                            if (endix >= 0) {
                                var xml = almostXml.Substring(i, (endix + endtag.Length) - i);
                                try {
                                    // see if this is really xml
                                    var doc = XDocument.Parse(xml);
                                    validXml.AppendLine(xml);
                                    i = (endix + endtag.Length);
                                    continue; // next iteration of while i
                                    }
                                catch (System.Xml.XmlException) {
                                    // do nothing
                                    }
                                }
                            }
                        }
                    }
                i++;
                }
            Console.WriteLine("-----------");
            Console.WriteLine("Valid XML found:");
            Console.WriteLine(validXml.ToString());
            Console.ReadKey();
            }
        }
    }
