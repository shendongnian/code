    public ActionResult Index(String PageName)
            {
                if (PageName == null)
                    {
                        List<PageTable> pages = PagesRepository.GetAllPages();
                        return View(pages);
                    }
                PageTable FindPageName = PagesRepository.GetPageByURL(PageName);
             
                if (FindPageName == null)
                    {
                        return Content(PageName);
                    }
                if (FindPageName != null)
                    {
                        return View(FindPageName);
                    }
                return View("");
            }
