    public void RecurseCodeElements(CodeElements elements, CodeElementAggregate aggregate) {
        // ...
        foreach (CodeElement element in elements) {
            // ...
            if (element.Kind == vsCMElement.vsCMElementModule) {
                RecurseCodeElements(GetMembers(element), aggregate.Add(element));
            }
            // ...
        }
    }
    
    private CodeElements GetMembers(CodeElement element) {
        // ...
        if (element.Kind == vsCMElement.vsCMElementModule) {
            return (element as CodeClass).Members;
        }
        // ...
    }
    public bool IsStackableElement {
        get
        {
            if (IsRoot) 
                // ...
                return (ElementType == CodeElementType.Class || ElementType == CodeElementType.Module || ... )
                // ...
        }
    }
    
    public static CodeElementType GetElementType(CodeElement element) {
        switch (element.Kind) {
            // ...
            case vsCMElement.vsCMElementModule:
                return CodeElementType.Module;
            // ...
        }
    }
    
    public void Draw() {
        // ...
        if (ElementType == CodeElementType.Module) {
            _elementStackPanel.Background = _appConfig.ClassBackgroundBrush;
        }
        // ...
    }
    
    public void Update() {
        // ...
        if (ElementType == CodeElementType.Module)
        {
            ElementLabel.AddExpander(_elementStackPanel);
            ElementLabel.AddPictureToSingleGrid(ElementInfo.ElementImage);
            ElementLabel.AddPictureToSingleGrid(ElementInfo.Accessibility.AccessibilityImage);
            ElementLabel.AddText(ElementInfo.Name, _appConfig.ClassTextBrush, _appConfig.HyperlinkTextImageSpacer, FontWeights.Bold);
        }
        // ...
    }
    
    private bool GetElementInfo() {
        // ...
        if (ElementInfo.ElementType == CodeElementType.Module) {
            ElementInfo.ElementImage = _appConfig.GetImage("staticclass");
        }
        // ...
    }
    
    private void ParseCodeElement() {
        // ...
        if (ElementInfo.ElementType == CodeElementType.Module)
        {
            ElementInfo.IsStackable = true;
            var codeClass = (CodeClass)Original;
            var codeClass2 = (CodeClass2)Original;
            ElementInfo.Accessibility = new AccessibilityContainer(_appConfig, codeClass.Access);
            ElementInfo.IsStatic = true;
        }
        // ...
    }
