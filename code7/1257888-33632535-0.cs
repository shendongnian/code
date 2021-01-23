    private static Dictionary<RadGridStringId, string> texts;
    
    private static void InitializeTexts()
    {
        texts = new Dictionary<RadGridStringId, string>();
        texts[RadGridStringId.ClearSortingMenuItem] = "Annuler les tris";
        texts[RadGridStringId.ConditionalFormattingMenuItem] = "Formatage conditionnel";
        texts[RadGridStringId.GroupByThisColumnMenuItem] = "Grouper par cette colonne";
        texts[RadGridStringId.UngroupThisColumn] = "Dégrouper cette colonne";
        texts[RadGridStringId.ColumnChooserMenuItem] = "Masqueur de colonnes";
        texts[RadGridStringId.HideMenuItem] = "Masquer cette colonne";
        texts[RadGridStringId.ConditionalFormattingBtnApply] = "Appliquer";
        texts[RadGridStringId.ColumnChooserFormCaption] = "Masqueur de colonnes";
        texts[RadGridStringId.ColumnChooserFormMessage] =
            "Ajouter ici une colonne\npour la faire disparaitre\ntemporairement de la vue";
        texts[RadGridStringId.GroupingPanelDefaultMessage] =
            "Ajouter ici une colonne pour faire un regroupement par cette colonne";
        texts[RadGridStringId.GroupingPanelHeader] = "Groupe par";
        texts[RadGridStringId.ClearValueMenuItem] = "Effacer la Valeur";
        texts[RadGridStringId.ConditionalFormattingContains] = "Contient [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingDoesNotContain] = "Ne contient pas [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingEndsWith] = "Finit par [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingEqualsTo] = "Est égal à [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingIsBetween] = "Est compris entre [Valeur1] et [Valeur2]";
        texts[RadGridStringId.ConditionalFormattingIsGreaterThan] = "Est supérieur à [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingIsGreaterThanOrEqual] = "Est supérieur ou égal à [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingIsLessThan] = "Est inférieur à [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingIsLessThanOrEqual] = "Est inférieur ou égal à [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingIsNotBetween] = "Non compris entre [Valeur1] et [Valeur2]";
        texts[RadGridStringId.ConditionalFormattingIsNotEqualTo] = "Est différent de [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingStartsWith] = "Commence par [Valeur1]";
        texts[RadGridStringId.ConditionalFormattingRuleAppliesOn] = "La règle s'applique au champ:";
        texts[RadGridStringId.ConditionalFormattingChooseOne] = "[Choisir un type]";
        texts[RadGridStringId.NoDataText] = "Pas de données à afficher";
    }
