	public static By ConvertToBy(this IWebElement element)
	{
		if (element == null) throw new NullReferenceException();
		var attributes =
			((IJavaScriptExecutor) SeleniumWebDriver.Driver).ExecuteScript(
				"var items = {}; for (index = 0; index < arguments[0].attributes.length; ++index) { items[arguments[0].attributes[index].name] = arguments[0].attributes[index].value }; return items;",
				element) as Dictionary<string, object>;
		if (attributes == null) throw new NullReferenceException();
		var selector = "//" + element.TagName;
		selector = attributes.Aggregate(selector, (current, attribute) =>
			 current + "[@" + attribute.Key + "='" + attribute.Value + "']");
		return By.XPath(selector);
	}
