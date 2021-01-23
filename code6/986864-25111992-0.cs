        private void buttonInsert_Click(object sender, EventArgs e)
        {
            MemberSkill newItem = MemberSkillBS.AddNew() as MemberSkill;
            if (newItem != null)
            {
                MemberSkillBS.Add(newItem);
            }
            ...
        }
