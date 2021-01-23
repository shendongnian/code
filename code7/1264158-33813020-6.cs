    public enum WeirdFamily { Child, Dad, Mother, TheThing }
 
    public static class AdamsFamilyFactory () {
        public static Version_X Create (WeirdFamily familyMember) {
            switch (familyMember) {
                case Dad:
                    return BuildAdamsDad();
             // . . . 
            }
        }
    }
    public static class MunstersFactory() { // Munsters implementation }
    // client code
    
    List<Version_X> AdamsFamily = new List<Version_X>();
    Version_1 Pugsly = AdamsFamilyFactory.Create(WeirdFamily.Child);
    AdamsFamily.Add(Pugsly);
    List<Version_X> Munsters= new List<Version_X>();
    Version_1 Eddie= MunstersFactory.Create(WeirdFamily.Child);
    Munsters.Add(Eddie);
    DoTheMonsterMash(Munsters);
    DoTheMonsterMash(AdamsFamily);
    public void DoTheMonsterMash(List<Version_X> someWeirdFamily {
        foreach (var member in someWeirdFamily)
            member.GoWildAndCrazy();
    }
