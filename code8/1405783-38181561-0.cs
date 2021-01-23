    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    
    class Program
    {
        static void Main()
        {
            var ser = new DataContractSerializer(typeof(GetGameSessionHistory));
            using (var ms = new MemoryStream())
            {
                var orig = new GetGameSessionHistory { GameSessionsValue =
                    new List<GameSession>() { new GameSession { } } };
                ser.WriteObject(ms, orig);
                ms.Position = 0;
                var clone = (GetGameSessionHistory)ser.ReadObject(ms);
                Console.WriteLine(clone?.GameSessionsValue.Count()); // prints 1
            }
        }
    
    }
    [DataContract]
    public class GetGameSessionHistory : ValueBaseCasinoIT
    {
        [DataMember]
        public GameSession[] GameSessions
        {
            get { return GameSessionsValue?.ToArray(); }
            set { GameSessionsValue = value; }
        }
        //[DataMember] // original version; fails with The get-only collection of type
                       // 'GameSession[]' returned a null value.
        //public GameSession[] GameSessions => GameSessionsValue?.ToArray<GameSession>();
    
        public IEnumerable<GameSession> GameSessionsValue { get; set; }
    }
    
    [DataContract]
    public class ValueBaseCasinoIT
    {
    }
    
    [DataContract]
    public class GameSession
    {
    }
