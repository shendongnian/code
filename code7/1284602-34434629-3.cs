    public class CharacterCreationScript : MonoBehaviour
    {
        public CharacterDetailsView characterDetailsView;
        private BaseCharacterClass createdCharacter;
        // ...
        void WarriorClicked()
        {
            createdCharacter = new BaseWarriorClass();
            UpdateCharacterDetailsView();
        }
        void MageClicked()
        {
            createdCharacter = new BaseMageClass();
            UpdateCharacterDetailsView();
        }
        void UpdateCharacterDetailsView()
        {
            characterDetailsView.SetModel(createdCharacter);
        }
    }
