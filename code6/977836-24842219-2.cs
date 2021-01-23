    public class GetRandomController : Controller
    {
        public string GetRandom()
        {
            var firstNames = new List<string> { "Hund", "Katt", "Hus", "Bil" };
    
            Random randNum = new Random();
            int aRandomPos = randNum.Next(firstNames.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).
    
            string currName = firstNames[aRandomPos];
    
            return currName;
        }
    }
