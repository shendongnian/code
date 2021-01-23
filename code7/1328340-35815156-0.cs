        public ActionResult Edit()
        {
            int userId = _memberRepository.ReturnMemberIdByMobile(User.Identity.Name);
            var model = _memberRepository.FindById(userId).First();
            return View(model); // pass this in as the model, do not use viewbag
        }
