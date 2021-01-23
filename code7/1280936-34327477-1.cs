    public class Quest {
       public string Name { get; set; }
       public bool IsCompleted { get; set; }
       private delegate mOnQuestDoThis, mOnQuestDoThat;
       public static Dictionary<string, Quest> All { get; set; }
       public static Quest CurrentQuest { get; set; }
    
       public Quest(string name, delegate onQuestDoThis, delegate onQuestDoThat) {
           Name = name;
           IsCompleted = false;
           mOnQuestDoThis = onQuestDoThis;
           mOnQuestDoThat = onQuestDoThat;
           All.Add(name, this);
           if(CurrentQuest == null) {
              CurrentQuest = this;
           } 
       }
       static Quest() { All = new Dictionary<string, Quest>(); }
       public DoThis(...) { mOnQuestDoThis(...); }
       public DoThat(...) { mOnQuestDoThat(...); }
    }
