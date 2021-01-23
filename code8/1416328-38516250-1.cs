    public class SampleButton : Button
    {
        protected override void OnClick(EventArgs e)
        {
            if(!criteriaToPrevent)
                base.OnClick(e);
        }
    }
