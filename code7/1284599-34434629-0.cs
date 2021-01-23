    public class CharacterDetailsView : MonoBehaviour
    {
        public UI.Text healthText;
        public UI.Text manaText;
        // ...
        public void SetModel(BaseCharacterClass chr)
        {
            healthText.text = chr.Health.ToString();
            manaText.text = chr.Mana.ToString();
            // ...
        }
    }
