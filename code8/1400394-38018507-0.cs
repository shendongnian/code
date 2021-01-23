      return unitOfWork.LegacyTaxReceiptStore.GetQuery()
            .Where(ltr => ltr.LegacyTaxReceiptId ==ltrm.LegacyTaxReceiptId)
            .AsEnumerable()
            .Select(c => new TaxReceiptsWithChargesModel()
            {
                LegacyTaxReceiptId = ltrm.LegacyTaxReceiptId,
                ChildContactId = ltrm.ChildContactId,
                ChildContact = ltrm.ChildContact,
                EmailAddress = ltrm.EmailAddress,
                ChildId = ltrm.ChildId,
                ChildName = ltrm.ChildName,
                ChargesTotal = ltrm.ChargesTotal,
                TaxReceiptAmount = ltrm.TaxReceiptAmount.Value,
                TaxReceiptYear = ltrm.TaxReceiptYear,
                Address = childContactAddress,
                ReceiptNumber = $"{ltrm.TaxReceiptYear}-{ltrm.LegacyTaxReceiptId.ToString().PadLeft(6, '0')}",
                Charges = taxReceiptChargesModelList,
            }).FirstOrDefault();
