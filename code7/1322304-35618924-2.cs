    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Serialization;
    
    
    
    namespace PPF_Converter_v6
    {
        //[XmlRoot("JMF", Namespace = "http://www.CIP4.org/JDFSchema_1_1")]
        public class JMF
        {
    
            [XmlAttribute("SenderID")]
            public string SenderID { get; set; }
    
            [XmlAttribute("Version")]
            public string Version { get; set; }
    
            public Command Command { get; set; }
    
            public JMF()
            {
                SenderID = "InkZone-Controller";
                Version = "1.2";
                Command = new Command();
            }
    
        }
        [XmlType("InkZoneProfile")]
        public class xmldata //Class to receive items list
        {
            [XmlIgnore]
            public string xml_filename { get; set; }
    
            [XmlAttribute("Separation")]
            public string colorname { get; set; }
    
            [XmlAttribute("ZoneSettingsX")]
            public string colorvalues { get; set; }
    
        }
        [Serializable]
        public class Command
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }
    
            [XmlAttribute("Type")]
            public string Type { get; set; }
    
            public ResourceCmdParams param;
    
            public Command()
            {
                ID = "cmd.00695";
                Type = "Resource";
                param = new ResourceCmdParams();
            }
            public ResourceCmdParams ResourceCmdParams { get; set; }
        }
        [Serializable]
        [XmlType("ResourceCmdParams")]
        public class ResourceCmdParams
        {
            [XmlAttribute("ResourceName")]
            public string ResourceName { get; set; }
    
            [XmlAttribute("JobID")]
            public string JobID { get; set; }
    
            public ResourceCmdParams()
            {
                ResourceName = "InkZoneProfile";
                JobID = "K_41";
            }
    
            public InkZoneProfile InkZoneProfile { get; set; }
        }
    
        [Serializable]
        public class InkZoneProfile
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }
    
            [XmlAttribute("Class")]
            public string Class { get; set; }
    
            [XmlAttribute("Locked")]
            public string Locked { get; set; }
    
            [XmlAttribute("Status")]
            public string Status { get; set; }
    
            [XmlAttribute("PartIDKeys")]
            public string PartIDKeys { get; set; }
    
            [XmlAttribute("DescriptiveName")]
            public string DescriptiveName { get; set; }
    
            [XmlAttribute("ZoneWidth")]
            public string ZoneWidth { get; set; }
    
            public InkZoneProfile()
            {
                ID = "r0013";
                Class = "Parameter";
                Locked = "False";
                Status = "Available";
                PartIDKeys = "SignatureName SheetName Side Separation";
                DescriptiveName = "Schieberwerte von DI";
                ZoneWidth = "32";
            }
    
            public InkZoneProfile2 InkZoneProfile2 { get; set; }
        }
        public class InkZoneProfile2 //Since InkZoneProfile was in use for class name, i just incremented it. Default name still is InkZoneProfile
        {
            [XmlAttribute("SignatureName")]
            public string SignatureName { get; set; }
    
            public InkZoneProfile2()
            {
                SignatureName = "SIG1";
            }
    
            public InkZoneProfile3 InkZoneProfile3 { get; set; }
    
        }
        public class InkZoneProfile3
        {
            [XmlAttribute("Locked")]
            public string Locked { get; set; }
    
            [XmlAttribute("SheetName")]
            public string SheetName { get; set; }
    
            public InkZoneProfile3()
            {
                Locked = "False";
                SheetName = "S1";
            }
        }
        public class xmldatalist
        {
            public List<xmldata> FullList = new List<xmldata>();
            public Dictionary<string, List<xmldata>> xmlFiles = new Dictionary<string, List<xmldata>>();
        }
        public class variables //All variables goes here - only smaller stuff goes into the code
        {
    
            public string aux { get; set; }
            public string colors { get; set; }
            public string[] colors_str { get; set; }
            public int nfiles { get; set; }
            public string definedpath { get; set; }
            public string contents { get; set; }
            public string values { get; set; }
            public string CompleteFileName { get; set; }
            public string[] FilesNames { get; set; }
    
        }
        class Program
        {
                JMF JMFConst = new JMF();
    
            public void writexml(xmldatalist XMLList, variables GlobalVars)
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = Environment.NewLine,
                    NewLineHandling = NewLineHandling.Replace,
                    Encoding = new UTF8Encoding(false)
                };
    
                foreach (var item in XMLList.FullList)
                {
                    if (!XMLList.xmlFiles.ContainsKey(item.xml_filename))
                    {
                        XMLList.xmlFiles[item.xml_filename] = new List<xmldata>();
                        XMLList.xmlFiles[item.xml_filename].Add(item);
                    }
    
                }
                string DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string XmlFilename = GlobalVars.CompleteFileName;
                XmlFilename = GlobalVars.CompleteFileName;
    
                string FileExtension = ".xml";
                string PathString = Path.Combine(DesktopFolder, "XML");
                System.IO.Directory.CreateDirectory(PathString);
                string FullPath = Path.Combine(PathString, XmlFilename + FileExtension);
                foreach (var i in XMLList.xmlFiles)
                {
                    string Xname = i.Key;
                    string XMLName = Path.Combine(PathString, Xname + FileExtension);
                    List<xmldata> xmlDataOfThisFile = i.Value;
                    Console.WriteLine(Xname);
                    try
                    {
                        using (XmlWriter XmlWriting = XmlWriter.Create(XMLName, settings))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(JMF));
                            serializer.Serialize(Console.Out, JMFConst);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }
            [STAThread]
            static void Main(string[] args)
            {
    
                variables v = new variables();
                xmldatalist XList = new xmldatalist();
                Program Methods = new Program();
    
    
                //var xml_list = new List<xmldata>(); //Initializing the list to store data to the XML File
                using (var folder1 = new FolderBrowserDialog())
                {
                    folder1.ShowNewFolderButton = false;
                    folder1.RootFolder = Environment.SpecialFolder.MyComputer;
                    DialogResult result = folder1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        v.definedpath = folder1.SelectedPath;
                        foreach (string file in Directory.EnumerateFiles(v.definedpath, "*.ppf"))
                        {
    
                            using (var fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                            {
                                v.CompleteFileName = file;
                                v.CompleteFileName = System.IO.Path.GetFileNameWithoutExtension(file);
                                string aux = "";
                                v.contents = "";
                                var len = (int)fs.Length;
                                var bits = new byte[len];
                                fs.Read(bits, 0, len);
                                // Dump 16 bytes per line
                                for (int ix = 0; ix < len; ix += 16)
                                {
                                    var cnt = Math.Min(16, len - ix);
                                    var line = new byte[cnt];
                                    Array.Copy(bits, ix, line, 0, cnt);
    
                                    // Convert non-ascii characters to .
                                    for (int jx = 0; jx < cnt; ++jx)
                                        if (line[jx] < 0x20 || line[jx] > 0x7f) line[jx] = (byte)'.';
                                    //Creating a big string with output
                                    aux = Encoding.ASCII.GetString(line);
                                    v.contents += aux;
                                }
    
    
    
                                //Manipulate the current file
                                bool b = v.contents.Contains("CIP3EndOfFile");
                                if (b)
                                {
    
                                    //Extracting color names (the ones we will have in the file).
                                    Regex regex = new Regex("CIP3AdmSeparationNames(.*)CIP3AdmPSExtent");
                                    var w = regex.Match(v.contents);
                                    string s = w.Groups[1].ToString();
                                    s = s.Replace("] def./", "").Replace("[", "").Replace(" (", "(").Replace("(", "").Replace(")", "|");
                                    s = s.Remove(s.Length - 1, 1);
                                    v.colors_str = s.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                    //Colors separated with a delimiter - | . Clean for using later.
                                    //Creating an array with colors - one position for each color found
    
                                    //Extracting color values
                                    Regex regex2 = new Regex("HDMZones(.*)>>");
                                    var v2 = regex2.Match(v.contents);
                                    string s2 = v2.Groups[1].ToString();
                                    s2 = s2.Replace("HDMZones <</", "").Replace("<</", "").Replace("/", "");
    
                                    //Extracting numbers inside brackets
                                    var pattern = @"\[(.*?)\]";
                                    var query = s2;
                                    var matches = Regex.Matches(query, pattern);
    
    
                                    int i = 0;
                                    foreach (Match m in matches)
                                    {
                                        v.values = "";
                                        Double[] numbers;
                                        string aux2 = "";
                                        aux2 = m.Groups[1].ToString();
                                        aux2 = Regex.Replace(aux2, @"\s+", "|");
                                        string[] numbers_str = aux2.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                        numbers = new Double[numbers_str.Length];
                                        for (int j = 0; j < numbers.Length; j++)
                                        {
                                            numbers[j] = Double.Parse(numbers_str[j], CultureInfo.InvariantCulture);
                                            //Converts each number on the string to a Double number, store it in a position
                                            //in the Double array
                                            numbers[j] = numbers[j] / 100; //Needed calculus
                                            numbers[j] = Math.Round(numbers[j], 3); //Storing numbers rounded
                                        }//Closing for loop for dividing numbers
                                        v.values = String.Join(" ", numbers.Select(f => f.ToString()));
                                        //outerList.Add(new List<string> { "one", "two", "three" })
    
                                        if (i < v.colors_str.Length)
                                        {
                                            XList.FullList.Add(new xmldata
                                            {
                                                colorname = v.colors_str[i],
                                                colorvalues = v.values,
                                                xml_filename = v.CompleteFileName,
                                            });
                                        }
    
                                        i++;
                                    }//Closing foreach m in matches (retrieves numbers related to colors)
                                }//Closing boolean B - Moment to write the XML
                            }//Closing filestream
                        }//closing foreach file
    
                    }//closing if dialogresult ok
    
    
                }//closing newfolderbrowserdialog
                Methods.writexml(XList, v);
    
                Console.ReadLine();
            }//End main
        }
    }
