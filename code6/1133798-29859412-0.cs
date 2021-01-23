    public static List<SelectItemOption> EnumAsSelectItemOptions<T>()
        where T : struct
    {
        var optionsList = new List<SelectItemOption>();
        foreach (var option in EnumToList<T>())   //** headache here **
        {
            optionsList.Add(new SelectItemOption()
            {
                Title = option is Enum
					? (option as Enum).GetDisplayName()
					: option.ToString(),
                ID = option.ToString(),
                Description = option is Enum
					? (option as Enum).GetDisplayDescription()
					: option.ToString(),
            });
        }
        return optionsList;
    }
