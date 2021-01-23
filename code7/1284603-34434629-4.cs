    public class CharacterDetailsView : MonoBehaviour
    {
        public Text healthText;
        public Text manaText;
        // ...
        public void SetModel(BaseCharacterClass chr)
        {
            healthText.text = chr.Health.ToString();
            manaText.text = chr.Mana.ToString();
            // ...
        }
    }
