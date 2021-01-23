        public class ClassB<T>
		{
			private static ClassA if_rect_Changed = new ClassA();
			public static void MethodB(Rect yourRect)
			{
				if (if_rect_Changed.RectChanged(yourRect))
				{
					Debug.Log("Changes were made");
				}
			}
		}
