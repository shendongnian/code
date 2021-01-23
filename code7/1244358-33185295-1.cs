    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    
    [DataContract]
    public class Root
    {
        [DataMember(Name = "items")]
        public Item[] Items { get; set; }
    }
    
    [DataContract]
    public class Item
    {
        [DataMember(Name = "view_count")]
        public int ViewCount { get; set; }
    
        [DataMember(Name = "answer_count")]
        public int AnswerCount { get; set; }
    
        [DataMember(Name = "score")]
        public int Score { get; set; }
    
        [IgnoreDataMember]
        public Date LastActivityDate { get; private set; }
        [DataMember(Name = "last_activity_date")]
        private long Date
        {
            set
            {
                LastActivityDate = value;
            }
            get
            {
                return LastActivityDate.ElapsedSeconds;
            }
        }
    }
    
    [DataContract]
    public class Date
    {
        [IgnoreDataMember]
        public long ElapsedSeconds { get; set; }
    
        public Date(long seconds)
        {
            ElapsedSeconds = seconds;
        }
    
        public static implicit operator Date(long seconds)
        {
            return new Date(seconds);
        }
    }
    
    static class Program
    {
        static void Main()
        {
            string json = 
                @"{
                    ""items"":
                    [
                        { 
                            ""view_count"":4,
                            ""answer_count"":0,
                            ""score"":0,
                            ""last_activity_date"":1445071150
                        }
                    ]
                }";
    
            var serializer = new DataContractJsonSerializer(typeof(Root));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var root = (Root)serializer.ReadObject(stream);
                Console.WriteLine(root.Items[0].LastActivityDate.ElapsedSeconds);
            }
        }
    }
