    if (this.TextView.Caret.Position.VirtualBufferPosition.IsInVirtualSpace)
    {
        // Convert any virtual whitespace to real whitespace by doing an empty edit at the caret position.
        _editorOperationsFactoryService.GetEditorOperations(TextView).InsertText("");
    }
