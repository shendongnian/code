	var session = HttpContext.Current.Session;
	var builder = new System.Text.StringBuilder();
	builder.AppendFormat("session[\"someKeyThatDoesNotExist\"] => value {0}", session["someKeyThatDoesNotExist"] ?? "null").AppendLine();
	builder.AppendFormat("session[\"ExistingKey\"] => value {0}", session["ExistingKey"] ?? "null").AppendLine();
	builder.AppendFormat("session[\"ExistingKey\"] != null => value {0}", session["ExistingKey"] != null).AppendLine();
	builder.AppendFormat("session[\"ExistingKey\"] != null ? 4 : 5 => value {0}", session["ExistingKey"] != null ? 4 : 5).AppendLine();
	builder.AppendFormat("session[\"ExistingKey\"] == null ? 4 : 5 => value {0}", session["ExistingKey"] == null ? 4 : 5).AppendLine();
	var totalDebugInfo = builder.ToString();
