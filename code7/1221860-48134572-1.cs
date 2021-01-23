	//
	// Summary:
	//     Returns a text input element.
	//
	// Parameters:
	//   htmlHelper:
	//     The HTML helper instance that this method extends.
	//
	//   expression:
	//     An expression that identifies the object that contains the properties to display.
	//
	//   format:
	//     A string that is used to format the input.
	//
	//   htmlAttributes:
	//     An object that contains the HTML attributes to set for the element.
	//
	// Type parameters:
	//   TModel:
	//     The type of the model.
	//
	//   TProperty:
	//     The type of the value.
	//
	// Returns:
	//     An input element whose type attribute is set to "text".
	public static MvcHtmlString TextBoxFor<TModel, TProperty>(
									this HtmlHelper<TModel> htmlHelper,
									Expression<Func<TModel, TProperty>> expression,
									string format,
									object htmlAttributes);
