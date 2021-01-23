	namespace EmptyConsole
	{
		class Shop<T> where T : IPurchaseable
		{
			public void CreateButton(T itemToBuy)
			{
				var button = CreateButtonImpl();
				button.onClick.AddListener(() => Buy(itemToBuy));
			}
			void Buy(T itemToBuy) { }
		}
		interface IPurchaseable { }
		class C : IPurchaseable { }
		class D : IPurchaseable { }
		class Program
		{
			static void Main(string[] args)
			{
				var shop = new Shop<C>();
				shop.CreateButton(new C());
			}
		}
	}
