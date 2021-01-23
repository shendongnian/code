    partial void UpdateMeterRead(MeterRead instance)
    {
        try
        {
            if (instance.usage_adjust != 0)
            {
                sp_ub_adjust_usage(instance.location_id, instance.meter_id, instance.group_id, instance.adjust_dt, instance.usage_adjust,
                    instance.meter_rd_id, instance.measure_id, instance.customer_id, BaseContext.CurrentSpid);
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }
    }
