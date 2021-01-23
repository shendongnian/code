        [HttpPost]
        public ActionResult Submit(string color)
        {
            string[] validColors = new string[] { "RED", "BLUE", "GREEN", "BLACK" };
            if (!validColors.Contains(color))
            {
                ViewBag.ErrorMessage = color + " is not a valid color.";
                return View();
            }
        }
