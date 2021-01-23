    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                field f = new field()
                {
                    fields = new List<Person>() {
                        new Person() {
                            cid = "abc",
                            field_type = "def",
                            label = "ghi",
                            required = "true",
                            field_options = new List<sizee>() {
                                new sizee() {
                                    size = "AAA",
                                    options = new List<option>() {
                                        new option() {
                                            checke = "123",
                                            label = "456",
                                        },
                                       new option() {
                                            checke = "789",
                                            label = "012",
                                        }
                                    }
                                },
                               new sizee() {
                                    size = "BBB",
                                    options = new List<option>() {
                                        new option() {
                                            checke = "321",
                                            label = "654",
                                        },
                                       new option() {
                                            checke = "987",
                                            label = "210",
                                        }
                                    }
                                }
                            }
                        },
                       new Person() {
                            cid = "xyz",
                            field_type = "def",
                            label = "ghi",
                            required = "true",
                            field_options = new List<sizee>() {
                                new sizee() {
                                    size = "AAA",
                                    options = new List<option>() {
                                        new option() {
                                            checke = "123",
                                            label = "456",
                                        },
                                       new option() {
                                            checke = "789",
                                            label = "012",
                                        }
                                    }
                                },
                               new sizee() {
                                    size = "BBB",
                                    options = new List<option>() {
                                        new option() {
                                            checke = "321",
                                            label = "654",
                                        },
                                       new option() {
                                            checke = "987",
                                            label = "210",
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(field));
                FileStream stream = File.OpenWrite(FILENAME);
                ser.WriteObject(stream, f);
                stream.Flush();
                stream.Close();
                stream.Dispose();
            }
        }
        [DataContract]
        public class field
        {
            [DataMember]
            public List<Person> fields { get; set; }
        }
        [DataContract]
        public class Person
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public string field_type { get; set; }
            [DataMember]
            public string required { get; set; }
            [DataMember]
            public string cid { get; set; }
            [DataMember]
            public List<sizee> field_options { get; set; }
        }
        [DataContract]
        public class sizee
        {
            [DataMember]
            public string size { get; set; }
            [DataMember]
            public List<option> options { get; set; }
        }
        [DataContract]
        public class option
        {
            [DataMember]
            public string checke { get; set; }
            [DataMember]
            public string label { get; set; }
        }
    }
    ​
