    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class MySpriteManager {
        private static Dictionary<string, Sprite> spriteMap = new Dictionary<string, Sprite>();
        
        public static void AddSprite(string key, Sprite value) {
            spriteMap.add(key, value);
        }
        
        public static Sprite GetSprite(string key) {
            return spriteMap[key];
        }
    }
