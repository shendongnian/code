	public class MyController : CachingController
	{
		[EtagFilter]
		public ActionResult IsMagic(string dragonName)
		{
			var isMagic = dragonName == "Puff";
			// ...
			SaveEtag();
			return new ActionResult(isMagic);
		}
	}
