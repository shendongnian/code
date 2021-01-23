    public static class WidgetDbExtension
    {
        public static void AddAdjacent(this Widget widget1, Widget widget2)
        {
            if (widget1.Id < widget2.Id)
            {
                widget1.AdjacentTo.Add(widget2);
            }
            else
            {
                widget2.AdjacentTo.Add(widget1);
            }
        }
        public static void RemoveAdjacent(this Widget widget1, Widget widget2)
        {
            if (widget1.Id < widget2.Id)
            {
                widget1.AdjacentTo.Remove(widget2);
            }
            else
            {
                widget2.AdjacentTo.Remove(widget1);
            }
        }
    }
