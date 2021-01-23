    public enum BehaviourType
    {
        JustDestroy,
        DestroyAndShowPoints,
        ShowPoints
    }
    public static class MyDelegatesFactory
    {
        public static Action Create(BehaviourType type,
            Action destroy, Action showPoints)
        {
            Action result = null;
            switch(type)
            {
                case BehaviourType.JustDestroy:
                    result = destroy;
                    break;
                case BehaviourType.DestroyAndShowPoints:
                    result = destroy;
                    result += showPoints;
                    break;
                case BehaviourType.ShowPoints:
                    result = showPoints;
                    break;
            }
            return result;
        }
    }
