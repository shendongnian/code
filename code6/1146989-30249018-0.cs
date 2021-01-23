    namespace EmptyConsole
	{
		class Shop<T>
		{
			public void CreateButton(T itemToBuy)
			{
				var button = CreateButtonImpl();
				button.onClick.AddListener(() => Buy(itemToBuy));
			}
			void Buy(T itemToBuy) { }
		}
		class C { }
		class D { }
		class Program
		{
			static void Main(string[] args)
			{
				var shop = new Shop<C>();
				shop.CreateButton(new C());
			}
		}
	}
