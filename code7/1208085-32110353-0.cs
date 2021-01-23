     string[] AchievementsList = Regex.Matches(strAchievements, @"\{.*?\}").Cast<Match>().Select(m => m.Value).ToArray();
                        for (i = 0; i < AchievementsList.Length; i++)
                        {
                            TestClass aJson = js.Deserialize<TestClass>(AchievementsList[i]); //use aJson object to access properties you  need
 
    }
