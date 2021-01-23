            var xmlSerializer = new XmlSerializer(typeof(Thesaurus));
            var r = new Thesaurus();
            r.Entries = new List<Entry>();
            r.Metadata = new Metadata();
            r.Entries.Add(new Entry()
            {
                Synonym = new Term[] { new Term(){Value = "1"}, new Term() {Value = "2"},   },
                Term = "Term1"
            });
            r.Entries.Add(new Entry()
            {
                Synonym = new Term[] { new Term() { Value = "3" }, new Term() { Value = "4" }, },
                Term = "Term2"
            });
            using (TextWriter writer = new StreamWriter(@"c:\111.xml"))
            {
                xmlSerializer.Serialize(writer, r);
                writer.Close();
            }
            using (TextReader reader = new StreamReader(@"c:\111.xml"))
            {
                Thesaurus tt = xmlSerializer.Deserialize(reader) as Thesaurus;
                Console.Write(tt.Entries.Count);
                reader.Close();
            }
