    using UnityEngine;
    using System.Collections;
    using System;
    
    [Serializable]
    public class Stats
    {
    
        public int driftTimeTotal, driftTimePresent;
        public int explodedTotal, explodedPresent;
        public int flagsTotal, flagsPresent;
        public int x2Total, x2Present;
        public int shieldTotal, shieldPresent;
        public int healthTotal, healthPresent;
        public int scoreTotal, scorePresents;
        public int finish1stTotal, finish1stPresent;
        public int bonusesTotal, bonusesPresent;
        public int hitsObjTotal, hitsObjPresent;
        public int hitsCarTotal, hitsCarPresent;
        public int jumpTotal, jumpPresent;
        public int index;
    
        public void SaveTotal()
        {
            string playerJson = JsonUtility.ToJson(this);
            PlayerPrefs.SetString("playerStats", playerJson);
        }
    
        public Stats ReadTotal()
        {
            string playerJson = PlayerPrefs.GetString("playerStats");
            if (playerJson == null)
            {
                return null;
            }
            Stats stats = JsonUtility.FromJson<Stats>(playerJson);
            return stats;
        }
    }
