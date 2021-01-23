	namespace EmptyConsole
	{
		class Shop<T> where T : I
		{
			public void CreateButton(T itemToBuy)
			{
				var button = CreateButtonImpl();
				button.onClick.AddListener(() => Buy(itemToBuy));
			}
			void Buy(T itemToBuy) { }
		}
		interface I { }
		class C : I { }
		class D : I { }
		class Program
		{
			static void Main(string[] args)
			{
				var shop = new Shop<C>();
				shop.CreateButton(new C());
			}
		}
	}
