    public static class IInputRecieverExtensions{
        public static void SubscribeToInput<T>(this T Reciever) where T : X, IInputReceiver { 
            //Use member of X
        }
        public static void UnsubscribeFromInput<T>(this T Reciever) where T : X, IInputReceiver {
            //Use member of X
        }
    }
