    public class MyCbx : CheckBox {
        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
            base.OnEnter(e);
            base.OnMouseEnter(e);
        }
        protected override void OnLostFocus(EventArgs e) {
            base.OnLostFocus(e);
            base.OnLeave(e);
            base.OnMouseLeave(e);
        }
        protected override void OnMouseLeave(EventArgs e) {
            if(!this.Focused) {//prevent it from losing highligh if control is in focus
                base.OnMouseLeave(e);
            }
        }
    }
