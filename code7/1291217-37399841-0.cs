        // Summary:
        //     Returns a select list for the given TEnum.
        //
        // Type parameters:
        //   TEnum:
        //     Type to generate a select list for.
        //
        // Returns:
        //     An System.Collections.Generic.IEnumerable`1 containing the select list for the
        //     given TEnum.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Thrown if TEnum is not an System.Enum or if it has a System.FlagsAttribute.
        IEnumerable<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : struct;
