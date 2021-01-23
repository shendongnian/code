    Contexte contexte = new Contexte();
    var listField = contexte.GetType().GetField("<offre_Stages>_k__BackingField", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    // either:
    IEnumerable<OS> fldVal = (IEnumerable<OS>)listField.GetValue(contexte); // don't use ``dynamic`` as we know it's an ``IEnumerable`1``
    fldVal.Where(os => os.id == 1);
    // or:
    dynamic fldVal = listField.GetValue(contexte);
    Enumerable.Where((IEnumerable<OS>)fldVal, os => os.id == 1); // explicit call to the extension method
