void BoringTest(object i)
{
   dynamic item = i;
   bool val = true;
   item.Enable = val;
   bool ret = item.Enable;
   VerifyEqual(val, ret);
   val = false;
   item.Enable = val;
   ret =item.Enable;
   VerifyEqual(val, ret);
}
public void GroupAEnable()
{
   BoringTest(mItem.GroupA);
}
public void GroupBEnable()
{
   BoringTest(mItem.GroupB);
}
