    protected override void OnDrawItem(DrawItemEventArgs e) {
      e.DrawBackground();
      bool isChecked = GetItemChecked(e.Index);
      Size checkSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, CheckBoxState.MixedNormal);
      CheckBoxRenderer.DrawCheckBox(e.Graphics,
        new Point(e.Bounds.Left + 2,
                  e.Bounds.Top + (e.Bounds.Height / 2) - (checkSize.Height / 2)),
        isChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
      TextRenderer.DrawText(e.Graphics, Items[e.Index].ToString(), Font,
        new Rectangle(e.Bounds.Left + checkSize.Width + 3, e.Bounds.Top,
                      e.Bounds.Width - (checkSize.Width + 3), e.Bounds.Height - 1),
        isChecked ? CheckedItemColor : ForeColor, Color.Empty, TextFormatFlags.VerticalCenter);
    }
