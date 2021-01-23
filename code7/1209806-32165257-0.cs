    public class QuestTracker : MonoBehaviour
    {
        public static QuestGiver questGiver;
        public Button AcceptQuest;
        public OpenQuestWindow questWindow;
    
        public void acceptQuest()
        {
            questGiver.questAccepted = true;
        }
    }
