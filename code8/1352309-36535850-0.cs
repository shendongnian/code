    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Forms;
    
    namespace SOFAcrobatics
    {
        class Meme
        {
            public String Name
            {
                get;
                set;
            }
    
            public String Topic
            {
                get;
                set;
            }
    
            public Boolean Popular
            {
                get;
                set;
            }
    
            public String Identifier
            {
                get;
                set;
            }
    
            public Meme (String name, String topic, Boolean popular, String identifier)
            {
                this.Name = name;
                this.Topic = topic;
                this.Popular = popular;
                this.Identifier = identifier;
            }
    
            public override string ToString()
            {
                return String.Format("(Identifier: {0}, Topic: {1}, Popular: {2}, Name: {3})",
                    this.Identifier,
                    this.Topic,
                    this.Popular,
                    this.Name);
            }
        }
    
        public static class Launcher
        {
            public static void Main ()
            {
                List<Meme> memes = new List<Meme>() {
                    new Meme ("name1", "topic1", false, "id1"),
                    new Meme ("name3", "topic2", true, "id2"),
                    new Meme ("name2", "topic3", false, "id3")
                };
    
                MessageBox.Show(Launcher.SearchByIdentifier(memes, "id2").ToString(),
                    "Search result for Meme name3",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
    
            private static Meme SearchByIdentifier (List<Meme> memes, String identifier)
            {
                return memes.Find(
                    m => (m.Identifier == identifier)
                    );
            }
        }
    }
