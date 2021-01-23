    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication20
    {
    public class Program
    {
        public class Message
        {
            public int Id { get; set; }
            public IdGroup IdGroup { get; set; }
        }
        public class IdGroup
        {
            public int Id { get; set; }
            public List<Message> Messages { get; set; }
        }
        public static Dictionary<int, List<Message>> SynchronizedChatMessages(List<Message> messages, Dictionary<int, int> data)
        {
            List<Predicate<Message>> predList = new List<Predicate<Message>>();
            //Built of list of indivIdual predicates
            foreach (var x in data)
            {
                var IdMessage = x.Key;
                var lastMessageId = x.Value;
                Predicate<Message> pred = m => m.IdGroup.Id == IdMessage && m.Id > lastMessageId;
                predList.Add(pred);
            }
            //compose the predicates
            Predicate<Message> compositePredicate = m =>
            {
                bool ret = false;
                foreach (var pred in predList)
                {
                    //If any of the predicates is true, the composite predicate is true (OR)
                    if (pred.Invoke(m) == true) { ret = true; break; }
                }
                return ret;
            };
            //do the query
            var messagesFound = messages.Where(m => compositePredicate.Invoke(m)).ToList();
            //get the individual distinct IdGroupIds
            var IdGroupIds = messagesFound.Select(x => x.IdGroup.Id).ToList().Distinct().ToList();
            //Create dictionary to return
            Dictionary<int, List<Message>> result = new Dictionary<int, List<Message>>();
            foreach (int i in IdGroupIds)
            {
                result.Add(i, messagesFound.Where(m => m.IdGroup.Id == i).ToList());
            }
            return result;
        }
        
        public static void Main(string[] args)
        {
            var item1 = new IdGroup { Id = 2, Messages = new List<Message>() };
            var item2 = new IdGroup { Id = 45, Messages = new List<Message>() };
            var item3 = new IdGroup { Id = 36, Messages = new List<Message>() };
            var item4 = new IdGroup { Id = 8, Messages = new List<Message>() };
            var message1 = new Message { Id = 3, IdGroup = item1 };
            var message2 = new Message { Id = 7, IdGroup = item1 };
            var message3 = new Message { Id = 9, IdGroup = item1 };
            item1.Messages.Add(message1);
            item1.Messages.Add(message2);
            item1.Messages.Add(message3);
            var message4 = new Message { Id = 4, IdGroup = item2 };
            var message5 = new Message { Id = 10, IdGroup = item2 };
            var message6 = new Message { Id = 76, IdGroup = item2 }; 
            item2.Messages.Add(message4);
            item2.Messages.Add(message5);
            item2.Messages.Add(message6);
            var message7 = new Message { Id = 6, IdGroup = item3 };
            var message8 = new Message { Id = 32, IdGroup = item3 };
            item3.Messages.Add(message7);
            item3.Messages.Add(message8);
            var message9 = new Message { Id = 11, IdGroup = item4 };
            var message10 = new Message { Id = 16, IdGroup = item4 };
            var message11 = new Message { Id = 19, IdGroup = item4 };
            var message12 = new Message { Id = 77, IdGroup = item4 }; 
            item4.Messages.Add(message9);
            item4.Messages.Add(message10);
            item4.Messages.Add(message11);
            item4.Messages.Add(message12);
            List<IdGroup> items = new List<IdGroup> { item1, item2, item3, item4 };
            List<Message> messages = new List<Message> { message1, message2, message3, message4, message5, message6,message7, message8, message9, message10, message11, message12};
            Dictionary<int, int> lastMessagesPerItem = new Dictionary<int, int> { { 2, 3 }, { 45, 10 }, { 36, 6 }, { 8, 11 } };
            var result = SynchronizedChatMessages(messages, lastMessagesPerItem);
            var discard = Console.ReadKey();                     
        }
    }
    }
