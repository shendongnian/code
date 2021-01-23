    using System;
    using UnityEngine;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using Random = System.Random;
    
    namespace Assets.Scripts.CharactersUtil
    {
        public class BaseCharacterClassWrapper : MonoBehaviour
        {
            //int[] basicUDLRMovementArray = new int[4];
    
            public List<BaseCharacterClass> CurrentEnnemies; 
            public int StartingHealth = 500;        
    
            public BaseCharacterClass CharacterClass;
    
    
            public CharacterHealthUI HealthUI;
            
            // Use this for initialization
            private void Start()
            {
                CharacterClass = new BaseCharacterClass(StartingHealth);  
                HealthUI = this.GetComponent<CharacterHealthUI>();
                HealthUI.CharacterHealth = CharacterClass.BaseStats.Health;
            }
    
            // Update is called once per frame
    
            private void Update()
            {
                //ExecuteBasicMovement();
            }
    
            //During an attack with any kind of character
            //TODO: Make sure that people from the same team cannot attack themselves (friendly fire)
            private void OnTriggerEnter([NotNull] Collider other)
            {
                if (other == null) throw new ArgumentNullException(other.tag);
                Debug.Log("I'm about to receive some damage");
                
                var characterStats = other.gameObject.GetComponent<BaseCharacterClassWrapper>().CharacterClass.BaseStats;
                
                var healthToAddOrRemove = other.gameObject.tag == "Healer" || other.gameObject.tag == "AIHealer" ? characterStats.Power : -1 * characterStats.Power;
                
                characterStats.Health.TakeDamageFromCharacter((int)healthToAddOrRemove);
                
                Debug.Log("I should have received damage from a bastard");
                
                if (characterStats.Health.CurrentHealth == 500)
                {
                    Debug.Log("This is a mistake, I believe I'm a god! INVICIBLE");
                }
            }
    
            /*
            public void ExecuteBasicMovement()
            {
                var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
                transform.position += move * BaseStats.Speed * Time.deltaTime;
            }
    
            //TODO: Make sure players moves correctly within the environment per cases
            public void ExecuteMovementPerCase()
            {
            }
            */
    
    
    
            public bool CanDoExtraDamage()
            {
                return CharacterClass.CanDoExtraDamage();
            }
        }
    }
