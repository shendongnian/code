    public void ChangeUIPropertys(dynamic UIObject, Color color , string Text , ... ) {
        //                        ^^^^^^^
        ChangeUiPropertyImpl(UIObject, color, text);
    }
    private void ChangeUIPropertysImpl(Textbox tb, Color color , string Text , ...) {
        tb.SetColor(color);
    }
    private void ChangeUIPropertysImpl(Label lbl, Color color , string Text , ...) {
        lbl.SetColor(color);
    }
