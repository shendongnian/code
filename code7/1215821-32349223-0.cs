                                        using (var loEntities = new Entities())
                                        {
                                            var nonWinnerGift = (from nw in loEntities.CorporateNonWinnerGift
                                            join um in loEntities.Users on nw.UserID equals um.Id
                                            where nw.IsDeleted != true && nw.CouponID == couponID
                                            select new
                                            {
                                            FullName = (um.FirstName + " " + um.LastName),
                                            Title = nw.Title,
                                            Description = nw.Description,
                                             LogoName = nw.LogoName,
                                             CouponID = nw.CouponID,
                                             IsDiscount = nw.IsDiscount,
                                             Discount = nw.Discount,
                                             Desclaiemer = nw.Desclaiemer
                                         }).SingleOrDefault();
                dynamic d = new ExpandoObject();
                d.FullName = nonWinnerGift.FullName;
                d.Title = nonWinnerGift.Title;
                d.Description = nonWinnerGift.Description;
                d.LogoName = nonWinnerGift.LogoName;
                d.CouponID = nonWinnerGift.CouponID;
                d.IsDiscount = nonWinnerGift.IsDiscount;
                d.Discount = nonWinnerGift.Discount;
                d.Desclaiemer = nonWinnerGift.Desclaiemer;
                return d;
            }
        }
