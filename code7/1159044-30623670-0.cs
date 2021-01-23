    @using (Html.BeingForm())
    {
        <li>one@Html.HiddenFor(x => x.Tags)</li>
        <li>two@Html.HiddenFor(x => x.Tags)</li>
        <li>three@Html.HiddenFor(x => x.Tags)</li>
        <li>four@Html.HiddenFor(x => x.Tags)</li>
        <li>five@Html.HiddenFor(x => x.Tags)</li>
        <input type="submit" value="Submit Tags" />
    }
