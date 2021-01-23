    Literal literalInner = new Literal();
    literalInner.Text = "Testing";
    Label lblInner = new Label();
    lblInner.Attributes.Add("SkinID", "required");
    Label lblOuter = new Label();
    lblOuter.ID = "lblPrimary";
    lblOuter.Controls.Add(literalInner);
    lblOuter.Controls.Add(lblInner);
    placeholder.Controls.Add(lblOuter);
