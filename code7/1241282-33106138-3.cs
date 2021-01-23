    using JetBrains.Annotations;
    using UnityEngine;
    using UnityEngine.UI;
    
    namespace Assets.Scripts.CharactersUtil
    {      
    
        public class HealthChangedEventArgs : EventArgs 
        {
            public float MinHealth { get; set; }
            public float MaxHealth { get; set; }
            public float CurrentHealth { get; set;}
            public HealthChangedEventArgs(float minHealth, float curHealth, float maxHealth) {
                MinHealth = minHealth;
                CurrentHealth = curHealth;
                MaxHealth = maxHealth;
            }
        }
    
    
        public class CharacterHealth {
            public int StartingHealth { get; set; }
            
            private int _currentHealth;
            public int CurrentHealth 
            { 
              get { return _currentHealth; } 
              set { 
                  _currentHealth = value;
                  if(HealthChanged!=null)
                    HealthChanged(this, new HealthChangedEventArgs(0f, _currentHealth, MaxHealth);
                }
            }      
            
            public bool isDead;
    
            private int _counter;
            private const int MaxHealth = 200;
    
            public event EventHandler<HealthChangedEventArgs> HealthChanged;
    
            // Use this for initialization
    
            public CharacterHealth(int sh)
            {
                StartingHealth = sh;
                CurrentHealth = StartingHealth;
            }
    
            public void TakeDamageFromCharacter([NotNull] BaseCharacterClass baseCharacter)
            {
                CurrentHealth -= (int)baseCharacter.BaseStats.Power;        
                if (CurrentHealth <= 0)
                    isDead = true;
            }
    
            public void TakeDamageFromCharacter(int characterStrength)
            {
                CurrentHealth -= characterStrength;
                if (CurrentHealth <= 0)
                    isDead = true;
            }
    
            public void RestoreHealth(BaseCharacterClass bs)
            {
                CurrentHealth += (int)bs.BaseStats.Power;
            }
            public void RestoreHealth(int characterStrength)
            {
                CurrentHealth += characterStrength;
            }
        }
    }
