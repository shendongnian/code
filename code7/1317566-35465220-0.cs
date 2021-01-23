    string escapedValues = values.Replace("\"", "\\\"").Replace("'", "\\'");
    ScriptManager.RegisterStartupScript(this,
                                        GetType(),
                                        "RecreateDynamicTextboxes",
                                        "javascript:RecreateDynamicTextboxes('" + escapedValues + "');",
                                        // ...
