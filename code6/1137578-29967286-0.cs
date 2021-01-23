        public static HtmlString YokoTextBoxFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper,
                                                                        Expression<Func<TModel, TProperty>> expression,
                                                                        string identifiant,
                                                                        string label)
        {
            string htmlString = string.Format("<span class=\"input\">" +
                                                    "{0}" +
                                                    "<label class=\"input-label label-yoko\" for=\"{1}\">" +
                                                        "<span class=\"label-content label-content-yoko\">{2}</span>" +
                                                    "</label>" +
                                                "</span>",
                                                htmlHelper.TextBoxFor(expression, new { @class = "input-field input-yoko", @id = identifiant }),
                                                identifiant,
                                                label);
            
            return new HtmlString(htmlString);
        }
