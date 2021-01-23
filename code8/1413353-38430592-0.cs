    var query = from m in IM.GetMaster()
            join co in CM.GetConsumers()
            on m.InvoiceId equals co.InvoiceId into temp2
            from co in temp2.DefaultIfEmpty()
            join ch in CCM.GetCharge()
            on new { co?.InvoiceId, co?.ConsumerId,  } equals new { ch.InvoiceId, ch.ConsumerId }   into temp
            from ch in temp.DefaultIfEmpty()
            orderby m.InvoiceId
            select new
            {
                InvioceID = m.InvoiceId,
                ConsumerID = co?.ConsumerId,
                ChargeID = ch?.ChargeId,
                Amount = ch?.Amount
            };
