    public static MvcHtmlString EnumWithOther<TModel, TEnum>(this HtmlHelper<TModel> html, TEnum e, string other)
    {
        string r = string.Empty; // Setup the return holder
        string label = e.GetType().Name; // Get the name of the Enum for the ID's
        r += html.EnumDropDownListFor(m => e, new { @id = label, @Name = label, @class = "form-control EnumWithOther" }); // Setup the dropdown for the enum
        r += html.TextBoxFor(m => other, new { @id = $"{label}Other", @Name = $"{label}Other" }); //Setup the textbox for other
        return new MvcHtmlString(r);
    }
