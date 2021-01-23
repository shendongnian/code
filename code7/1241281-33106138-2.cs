    using JetBrains.Annotations;
    using UnityEngine;
    using UnityEngine.UI;
    
    namespace Assets.Scripts.CharactersUtil
    {
        public class CharacterHealthUI : MonoBehavior {
          public Image Fill;
          public Color MaxHealthColor = Color.green;
          public Color MinHealthColor = Color.red;   
          public Slider HealthSlider;
          
          private void Start() {
              if(!HealthSlider) {
                HealthSlider = this.GetComponent<Slider>();            
              }
              if(!Fill) {
                Fill = this.GetComponent<Image>();
              }          
          }
          
          private CharacterHealth _charaHealth;
          public CharacterHealth CharacterHealth { 
            get { return _charaHealth; }
            set { 
            if(_charaHealth!=null)
                _charaHealth.HealthChanged -= HealthChanged;
              _charaHealth = value; 
              _charaHealth.HealthChanged += HealthChanged;
            }
          }
        
          public HealthChanged(object sender, HealthChangedEventArgs hp) {
                HealthSlider.wholeNumbers = true; 
                HealthSlider.minValue = hp.MinHealth;
                HealthSlider.maxValue = hp.MaxHealth;
                HealthSlider.value = hp.CurrentHealth;  
                Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)hp.CurrentHealth / hp.MaxHealth);
          }
        
        }
        
    }
    
