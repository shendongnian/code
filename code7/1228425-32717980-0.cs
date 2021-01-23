    public class CardEffects
    {
        public static void ResolveRealmFestival(GameObject gameObject)
        {
            var politicalProblems = gameObject.AddComponent<PoliticalProblems>();
            politicalProblems.AdjustHeresy(false);
        }
    }
