    using System;
    using UnityEngine;
    namespace Assets.Scripts
    {
        /// <summary>
        /// Description of ISaveLoadGameData.
        /// </summary>
        public interface ISaveLoadGameData
        {
            void SaveForWeb();
            void SaveForX86();
            void Save();
            void UpdateGameState();
        }
    }
    using System;
    using UnityEngine;
    namespace Assets.Scripts
    {
        /// <summary>
        /// Description of SaveLoadGameDataController.
        /// </summary>
        [Serializable]
        public class SaveLoadGameDataController : ISaveLoadGameData
        {
            ISaveLoadGameData slgdInterface;
            GameObject gameObject;
            
            public static SaveLoadGameDataController gameState;
            
            public float experience = Helper.DEFAULT_EXPERIENCE;
            public float score = Helper.DEFAULT_SCORE;
            
            public void SetSaveLoadGameData (ISaveLoadGameData slgd)
            {
                slgdInterface = slgd;
            }
            
            public void SaveForWeb ()
            {
                slgdInterface.SaveForWeb();
            }
            
            public void SaveForX86 ()
            {
                slgdInterface.SaveForX86();
            }
            
            public void Save ()
            {
                slgdInterface.Save();
            }
            
            public void UpdateGameState ()
            {
                slgdInterface.UpdateGameState();
            }
        }
    }
