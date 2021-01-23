        if (radAsc.Checked)
        {
            for (int num = fromNum; num <= toNum; ++num) {
              lstResult.Items.Add(num);
              total = total + num;
            }
        }
        else
        {
            // Descending order: 
            //   - start from the bottom (toNum)
            //   - loop until the top (fromNum) 
            //   - descend by 1 (--num)
            for (int num = toNum; num >= fromNum; --num) {
              lstResult.Items.Add(num);
              total = total + num;
            }
        }
