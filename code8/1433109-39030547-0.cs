    interface ICombatant
    {
        int TakeDamage(int damageAmount);
        string GetHealthDisplay();
        public string CharacterName
        {
            get;
            set;
        }
    }
